using AkademiPlusSignalAr.DAL;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusSignalAr.Hubs
{
    public class MyHub : Hub
    {
        //Kişilerimi tutacak olan İsim Listesi
        public static List<string> Names { get; set; } = new List<string>();
        // o anda kaç tane client bağlı olduğunu gösteren proporti
        public static int ClientCount { get; set; } = 0;
        //Bir odada maksimum bulunacak kişi sayısı
        public static int RoomUserCount { get; set; } = 5;

        private readonly Context _context;

        public MyHub(Context context)
        {
            _context = context;
        }
        public async Task sendname(string name)
        {
            
            
                //if (Names.Count >= RoomUserCount)
                //{
                //    await Clients.Caller.SendAsync("error", $"Bu odada en fazla {RoomUserCount} kişi olabilir.");
                //}
                //else
                //{
                //    Names.Add(name);
                //    await Clients.All.SendAsync("receivename", name);    //isim ekleme işlemi.
                //}
            
            Names.Add(name);
            await Clients.All.SendAsync(method: "receivename", name);
        }
        public async Task GetNames()
        {
            await Clients.All.SendAsync( "receivenames", Names); //isim listesinin tümünü almak için

        }
        public   async override  Task OnConnectedAsync()
        {
           
            ClientCount++;
            await Clients.All.SendAsync( "receiveclientcount", ClientCount);
        }
        public async override  Task OnDisconnectedAsync(Exception exception)
        {
            ClientCount--;
            await Clients.All.SendAsync( "receiveclientcount", ClientCount);
        }
        //public async Task SendNameByGroup(string name, string roomName)
        //{
        //    var room = _context.rooms.Where(x => x.RoomName == roomName).FirstOrDefault();
        //    if (room != null)
        //    {
        //        room.Users.Add(new User()
        //        {
        //            UserName = name
        //        });
        //    }
        //    else
        //    {

        //    }
        //}
    }
}
