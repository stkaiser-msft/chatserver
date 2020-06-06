using System;
namespace chatserver {
    public class User {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public DateTime ConnectionTime { get; set; }
        public string Status { get; set; }
        public DateTime StatusTime { get; set; }
        

    }
}