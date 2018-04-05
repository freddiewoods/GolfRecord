// Copyright Naked Objects Group Ltd, 45 Station Road, Henley on Thames, UK, RG9 1AT
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0.
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and limitations under the License.

using System;
using NakedObjects.Architecture.Menu;
using NakedObjects.Core.Configuration;
using NakedObjects.Menu;
using NakedObjects.Persistor.Entity.Configuration;
using GolfRecord.Model;
using GolfRecord.DataBase;
using NakedObjects.Meta.Authorization;

namespace NakedObjects.GolfRecord {
    public class NakedObjectsRunSettings
    {

        public static string RestRoot
        {
            get { return ""; }
        }

        private static string[] ModelNamespaces
        {
            get
            {
                return new string[] { "GolfRecord.Model" }; //Add top-level namespace(s) that cover the domain model
            }
        }

        private static Type[] Types
        {
            get
            {
                return new Type[] {
                    typeof(Stableford),
                    typeof(Strokeplay),
                    typeof(Matchplay),
                    typeof(FourPlayerHoleScore),
                    typeof(TwoPlayerHoleScore),
                    typeof(ClubManager),
                    typeof(Player),
                    typeof(MatchInvitation),
                    typeof(FriendInvitation),
                    typeof(GroupInvitation),
                    typeof(RequestToJoin),
                    typeof(PlayerMessage),
                    typeof(GroupMessage)
                    //You need only register here any domain model types that cannot be
                    //'discovered' by the framework when it 'walks the graph' from the methods
                    //defined on services registered below
                };
            }
        }

        private static Type[] Services
        {
            get
            {
                return new Type[] {
                    typeof(GolferServices),
                    typeof(MatchServices),
                    typeof(CourseServices),
                    typeof(HoleServices),
                    typeof(FacilityServices)
            };
                }
        }

        public static ReflectorConfiguration ReflectorConfig()
        {
            return new ReflectorConfiguration(Types, Services, ModelNamespaces, MainMenus);
        }

        public static EntityObjectStoreConfiguration EntityObjectStoreConfig()
        {
            var config = new EntityObjectStoreConfiguration();
            config.UsingCodeFirstContext(() => new GolfRecordDbContext("NakedObjectsGolfRecord"));
            return config;
        }

        public static IMenu[] MainMenus(IMenuFactory factory)
        {
            return new IMenu[] {
                factory.NewMenu<GolferServices>(true, "Golfers"),
                factory.NewMenu<MatchServices>(true,"Matches"),
                factory.NewMenu<CourseServices>(true,"Courses")
            };
        }
        public static IAuthorizationConfiguration AuthorizationConfig()
        {
            var config = new AuthorizationConfiguration<DefaultAuthorizer>();
            //  config.AddNamespaceAuthorizer<MyAppAuthorizer>("MyApp");
            //  config.AddNamespaceAuthorizer<MyCluster1Authorizer>("MyApp.MyCluster1");
            config.AddTypeAuthorizer<Strokeplay, StrokePlayAuthoriser>();
            config.AddTypeAuthorizer<Stableford, StablefordAuthoriser>();
            config.AddTypeAuthorizer<Matchplay, MatchplayAuthoriser>();
            config.AddTypeAuthorizer<Player, PlayerAuthoriser>();
            config.AddTypeAuthorizer<ClubManager, ClubManagerAuthoriser>();
            config.AddTypeAuthorizer<Hole, HoleAuthorier>();
            config.AddTypeAuthorizer<Match, MatchAuthoriser>();
            config.AddTypeAuthorizer<Group, GroupAuthoriser>();
            config.AddTypeAuthorizer<Course, CourseAuthoriser>();
            config.AddTypeAuthorizer<Invitation, InvitationAuthoriser>();
            return config;
        }

    }
}