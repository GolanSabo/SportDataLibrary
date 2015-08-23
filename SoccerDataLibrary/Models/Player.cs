using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDataLibrary.Models
{
    /// <summary>
    /// class represnting a player.
    /// </summary>
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

        /// <summary>Gets the ID of the player in the current Web Service </summary>
        public int Id { private set { id = value; } get { return id; } }
        /// <summary>Gets the name of the player</summary>
        public String Name { private set { name = value; } get { return name; } }
        /// <summary>Gets the position of the player on field</summary>
        public String Position { private set { position = value; } get{ return position; } }
        /// <summary>Gets the number on shirt of the player</summary>
        public int JerseyNumber { private set { jerseyNumber = value; } get { return jerseyNumber; } }
        /// <summary>Gets the date of birth of the player</summary>
        public String DateOfBirth { private set { dateOfBirth = value; } get { return dateOfBirth; } }
        /// <summary>Gets the nationality of the player</summary>
        public String Nationality { private set { nationality = value; } get { return nationality; } }
        /// <summary>Gets the Date of the end of the contract of the player</summary>
        public String ContractUntil { private set { contractUntil = value; } get { return contractUntil; } }
        /// <summary>Gets the market value of the player</summary>
        public String MarketValue {
            private set {
                if (value == null)
                    marketValue = "Unavailable";
                else
                {
                    marketValue = value.Split(' ')[0];
                    if (marketValue != "Unavailable")
                        marketValue += "Euro";
                }
            }
            get {
                return marketValue;
            }
        }
        /// <summary>Returns the details of a player ready for print.</summary>
        public override String ToString()
        { 
            return "Name: " + Name + "\nId: " + Id + "\nPosition: " + Position + "\nJersey Number: " + JerseyNumber + "\nDate Of Birth: " + DateOfBirth + "\nNationality: " + Nationality + "\nContractUntil: " + ContractUntil + "\nMarket Value: " + MarketValue + "\n";
        }
    }
}
