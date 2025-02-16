using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsLangVersion.Fdmts_CollectionType.ListTest.PersonHaveFriend;

namespace CsLangVersion.Fdmts_CollectionType {
    public partial class ListTest {
        public class PersonHaveFriend {
            public enum FriendEnum {
                T0, T1
            }
            public class Friend {
                public FriendEnum FriendEm { get; set; }
                public string Alias { get; set; }
            }
            public List<Friend> Friends { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        [Test]
        public void 使用Linq_SelectMany实现成员集合铺平() {
            System.Console.WriteLine(@$"UT Excuted {nameof(ListTest)}_{nameof(使用Linq_SelectMany实现成员集合铺平)}");
            var listPerson = new List<PersonHaveFriend> {
                new PersonHaveFriend { Name="SCsc",Age=18, Friends=new List<Friend>
                {
                    new Friend{ FriendEm=FriendEnum.T0,Alias="MyFriendNb" },
                    new Friend{ FriendEm=FriendEnum.T1,Alias="MyFriendDog" },
                } }
            };
            var result = listPerson
    .SelectMany(p => p.Friends, (person, friend) => new {
        person.Name,
        person.Age,
        FriendType = friend.FriendEm,
        Alias = friend.Alias
    })
    .ToList();
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }

    }
}
