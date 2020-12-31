using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTestApi.Dtos;
using FinalTestApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinalTestApi.Data {
    public class DataRepo : IDataRepo {
        public static Connection Connection = new Connection ();
        private readonly LeagueContext _context;
        public DataRepo (LeagueContext context) {
            _context = context;
        }
        public async Task<int> CreateMatchAsync (Match match) {
            string connStr = Connection.ConnStr;
            int row_effect = 0;
            using (var conn = new NpgsqlConnection (connStr)) {
                await conn.OpenAsync ();
                var cmdStr = "Insert into match values(@matchid,@date,@attendance," +
                    "@homeid,@awayid,@stadiumid);";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", match.MatchID);
                    cmd.Parameters.AddWithValue ("@date", match.Datetime);
                    cmd.Parameters.AddWithValue ("@attendance", match.Attendance);
                    cmd.Parameters.AddWithValue ("@homeid", match.HomeResTeamID);
                    cmd.Parameters.AddWithValue ("@awayid", match.AwayResTeamID);
                    cmd.Parameters.AddWithValue ("@stadiumid", match.StadiumID);
                    row_effect = await cmd.ExecuteNonQueryAsync ();

                }

            }
            return row_effect;
        }

        public async Task<int> CreatePlayerAsync (Player player) {
            string connStr = Connection.ConnStr;
            int row_effect = 0;
            using (var conn = new NpgsqlConnection (connStr)) {
                await conn.OpenAsync ();
                var cmdStr = "Insert into player values(@playerid,@firstname,@lastname," +
                    "@kit,@position,@country,@teamid,@countryimage);";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@playerid", player.PlayerID);
                    cmd.Parameters.AddWithValue ("@firstname", player.FirstName);
                    cmd.Parameters.AddWithValue ("@lastname", player.LastName);
                    cmd.Parameters.AddWithValue ("@kit", player.Kit);
                    cmd.Parameters.AddWithValue ("@position", player.Position);

                    cmd.Parameters.AddWithValue ("@country", player.Country);
                    cmd.Parameters.AddWithValue ("@teamid", player.TeamID);

                    cmd.Parameters.AddWithValue ("@countryimage", player.CountryImage);
                    row_effect = await cmd.ExecuteNonQueryAsync ();

                }

            }
            return row_effect;
        }

        public Task<int> CreateResultAsync (Result result) {
            throw new NotImplementedException ();
        }

        public Task<int> CreateScoreAsync (Score score) {
            throw new NotImplementedException ();
        }

        public Task<int> CreateTeamAsync (Team team) {
            throw new NotImplementedException ();
        }

        public async Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync () {
            var listMatch = new List<MatchInfoDtos> ();
            string connStr = Connection.ConnStr;
            using (var conn = new NpgsqlConnection (connStr)) {
                await conn.OpenAsync ();
                var cmdStr = "Select * from match_info_dto4";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                    while (rd.Read ()) {
                    var match = new MatchInfoDtos {
                    MatchID = Convert.ToInt32 (rd["MatchID"]),

                    Datetime = Convert.ToDateTime (rd["Datetime"]),
                    Attendance = Convert.ToInt32 (rd["Attendance"]),
                    HomeName = Convert.ToString (rd["HomeName"]),
                    AwayName = Convert.ToString (rd["AwayName"]),
                    StadiumName = Convert.ToString (rd["StadiumName"]),
                    HomeRes = Convert.ToInt32 (rd["HomeRes"]),
                    AwayRes = Convert.ToInt32 (rd["AwayRes"]),
                    HomeImage = Convert.ToString (rd["HomeImage"]),
                    AwayImage = Convert.ToString (rd["AwayImage"])

                            };
                            listMatch.Add (match);
                        }
                    }
                }
            }
            return listMatch;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync () {
            var conStr = Connection.ConnStr;
            var listPlayers = new List<Player> ();
            using (var con = new NpgsqlConnection (conStr)) {
                var cmdStr = "Select * from player";
                using (var cmd = new NpgsqlCommand (cmdStr, con)) {
                    await con.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                        var player = new Player {
                        PlayerID = Convert.ToInt32 (rd["PlayerID"]),
                        FirstName = Convert.ToString (rd["FirstName"]),
                        LastName = Convert.ToString (rd["LastName"]),
                        Kit = Convert.ToInt32 (rd["Kit"]),
                        Position = Convert.ToString (rd["Position"]),
                        Country = Convert.ToString ("Country"),
                        TeamID = Convert.ToInt32 (rd["TeamID"]),
                        CountryImage = Convert.ToString (rd["CountryImage"])
                            };
                            listPlayers.Add (player);
                        }
                    }
                }
            }
            return listPlayers;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync () {

            var listTeam = new List<Team> ();
            string connStr = Connection.ConnStr;
            using (var conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from team";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ();
                    while (rd.Read ()) {
                        var team = new Team {
                            TeamID = rd.GetInt32 (0),
                            TeamName = rd.GetString (1),
                            StadiumID = rd.GetInt32 (2),
                            TeamImage = rd.GetString (3)

                        };
                        listTeam.Add (team);

                    }
                }
            }
            return listTeam;
        }

        public async Task<MatchInfoDtos> GetMatchByIdAsync (int matchId) {
            var connStr = Connection.ConnStr;
            var match = new MatchInfoDtos ();
            using (var conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from match_info_dto4 where \"MatchID\"=@matchid;";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", matchId);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            match.MatchID = Convert.ToInt32 (rd["MatchID"]);

                            match.Datetime = Convert.ToDateTime (rd["Datetime"]);
                            match.Attendance = Convert.ToInt32 (rd["Attendance"]);
                            match.HomeName = Convert.ToString (rd["HomeName"]);
                            match.AwayName = Convert.ToString (rd["AwayName"]);
                            match.StadiumName = Convert.ToString (rd["StadiumName"]);
                            match.HomeRes = Convert.ToInt32 (rd["HomeRes"]);
                            match.AwayRes = Convert.ToInt32 (rd["AwayRes"]);
                            match.HomeImage = Convert.ToString (rd["HomeImage"]);
                            match.AwayImage = Convert.ToString (rd["AwayImage"]);
                        }
                    }

                }
            }
            return match;
        }

        public async Task<Player> GetPlayerByIdAsync (int? id) {
            var conStr = Connection.ConnStr;
            var player = new Player ();
            using (var conn = new NpgsqlConnection (conStr)) {
                await conn.OpenAsync ();
                var cmdStr = "select * from player where \"PlayerID\"=@playerid;";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@playerid", id);
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            player.PlayerID = Convert.ToInt32 (rd["PlayerID"]);
                            player.FirstName = Convert.ToString (rd["FirstName"]);
                            player.LastName = Convert.ToString (rd["LastName"]);
                            player.Kit = Convert.ToInt32 (rd["Kit"]);
                            player.Position = Convert.ToString (rd["Position"]);
                            player.Country = Convert.ToString ("Country");
                            player.TeamID = Convert.ToInt32 (rd["TeamID"]);
                            player.CountryImage = Convert.ToString (rd["CountryImage"]);
                        }
                    }
                }

            }
            return player;
        }

        public async Task<IEnumerable<Score>> GetAllScoresAsync () {
            var listScore = new List<Score> ();
            string connStr = Connection.ConnStr;
            using (var conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from score";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ();
                    while (rd.Read ()) {
                        var score = new Score {
                            ScoreID = rd.GetInt32 (0),
                            MatchID = rd.GetInt32 (1),
                            PlayerID = rd.GetInt32 (2),
                            TeamID = rd.GetInt32 (3)

                        };
                        listScore.Add (score);

                    }
                }
                return listScore;
            }
        }

        public async Task<Stadium> GetStadiumByNameAsync (string name) {
            Stadium stadium = new Stadium ();
            var connStr = Connection.ConnStr;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from stadium where \"StadiumName\"=@name;";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            stadium.StadiumID = Convert.ToInt32 (rd["StadiumID"]);
                            stadium.StadiumName = Convert.ToString (rd["StadiumName"]);
                            stadium.City = Convert.ToString (rd["City"]);
                            stadium.Capacity = Convert.ToInt32 (rd["Capacity"]);

                        }
                    }
                }
            }
            return stadium;
        }

        public async Task<Team> GetTeamByIdAsync (int id) {
            var conStr = Connection.ConnStr;
            var team = new Team ();
            using (var conn = new NpgsqlConnection (conStr)) {
                await conn.OpenAsync ();
                var cmdStr = "Select * from team where \"TeamID\"=@teamid";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@teamid", id);
                    NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ();
                    while (rd.Read ()) {
                        team.TeamID = rd.GetInt32 (0);
                        team.TeamName = rd.GetString (1);
                        team.StadiumID = rd.GetInt32 (2);
                        team.TeamImage = rd.GetString (3);
                    }
                }
            }
            return team;
        }

        public async Task<Team> GetTeamByNameAsync (string name) {
            Team team = new Team ();
            var connStr = Connection.ConnStr;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from team where \"TeamName\"=@name;";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            team.TeamID = Convert.ToInt32 (rd["TeamID"]);
                            team.TeamName = Convert.ToString (rd["TeamName"]);
                            team.StadiumID = Convert.ToInt32 (rd["StadiumID"]);
                            team.TeamImage = Convert.ToString (rd["TeamImage"]);

                        }
                    }
                }
            }
            return team;
        }

        public Task<bool> SaveChangesAsync () {
            throw new NotImplementedException ();
        }

        public async Task<int> UpdatePlayerAsync (int id, Player player) {
            int row_effect = 0;
            var connStr = Connection.ConnStr;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Update player set \"FirstName\"=@firstname," +
                    "\"LastName\"=@lastname,\"Kit\"=@kit,\"Position\"=@position," +
                    "\"Country\"=@country,\"TeamID\"=@teamid,\"CountryImage\"=@countryimage where \"PlayerID\"=@playerid;";
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    cmd.Parameters.AddWithValue ("@playerid", id);
                    cmd.Parameters.AddWithValue ("@firstname", player.FirstName);
                    cmd.Parameters.AddWithValue ("@lastname", player.LastName);
                    cmd.Parameters.AddWithValue ("@kit", player.Kit);
                    cmd.Parameters.AddWithValue ("@position", player.Position);

                    cmd.Parameters.AddWithValue ("@country", player.Country);
                    cmd.Parameters.AddWithValue ("@teamid", player.TeamID);

                    cmd.Parameters.AddWithValue ("@countryimage", player.CountryImage);
                    row_effect = await cmd.ExecuteNonQueryAsync ();
                }
            }
            return row_effect;
        }

        Task<bool> checkExist (int homeId, int awayId) {
            throw new NotImplementedException ();
        }

        public Task<Team> GetTeamAsync (int? id) {
            throw new NotImplementedException ();
        }

        Task<bool> IDataRepo.checkExist (int homeId, int awayId) {
            throw new NotImplementedException ();
        }

        /*public async Task<Player> UpdatePlayerAsync_ver1 (int id, JsonPatchDocument<Player> playerJson) {
            var player = new Player ();

            player = await _context.Players.FirstOrDefaultAsync (x => x.PlayerID == id);
            playerJson.ApplyTo (player);
            return player;*/

        }
    
}