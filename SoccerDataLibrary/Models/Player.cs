using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDataLibrary.Models
{
    class Player
    {
        private int id;
        private String name;
        private String position;
        private int jerseyNumber;
        private String dateOfBirth;
        private String nationality;
        private String contractUntil;
        private String marketValue;

        public Player(int id, String name, String position, int jerseyNumber, String dateOfBirth,
                      String nationality, String contractUntil, String marketValue)
        {
            Id = id;
            Name = name;
            Position= position;
            JerseyNumber = jerseyNumber;
            DateOfBirth = dateOfBirth;
            Nationality = nationality;
            ContractUntil = contractUntil;
            MarketValue = marketValue;
        }


        public int Id { private set { id = value; } get { return id; } }
        public String Name { private set { name = value; } get { return name; } }
        public String Position { private set { position = value; } get{ return position; } }
        public int JerseyNumber { private set { jerseyNumber = value; } get { return jerseyNumber; } }
        public String DateOfBirth { private set { dateOfBirth = value; } get { return dateOfBirth; } }
        public String Nationality { private set { nationality = value; } get { return nationality; } }
        public String ContractUntil { private set { contractUntil = value; } get { return contractUntil; } }
        public String MarketValue { private set { marketValue = value; } get { return marketValue; } }

        public override String ToString()
        {
            return "Name: " + Name + "\nId: " + Id + "\nPosition: " + Position + "\nJerseyNumber: " + JerseyNumber + "\nDateOfBirth: " + DateOfBirth + "\nNationality: " + Nationality + "\nContractUntil: " + ContractUntil + "\nMarketValue: " + MarketValue + "\n";
        }
    }
}
