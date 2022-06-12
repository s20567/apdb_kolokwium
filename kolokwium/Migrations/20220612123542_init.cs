﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.IdMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_MusicLabels_IdMusicLabel",
                        column: x => x.IdMusicLabel,
                        principalTable: "MusicLabels",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdMusicAlbum = table.Column<int>(type: "int", nullable: true),
                    IdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_IdAlbum",
                        column: x => x.IdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum");
                });

            migrationBuilder.CreateTable(
                name: "MusicianTracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false),
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianTracks", x => new { x.IdTrack, x.IdMusician });
                    table.ForeignKey(
                        name: "FK_MusicianTracks_Musicians_IdMusician",
                        column: x => x.IdMusician,
                        principalTable: "Musicians",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianTracks_Tracks_IdTrack",
                        column: x => x.IdTrack,
                        principalTable: "Tracks",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[,]
                {
                    { 1, "Label1" },
                    { 2, "Label2" }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "janek" },
                    { 2, "John", "Doe", "JD" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdAlbum", "IdMusicAlbum", "TrackName" },
                values: new object[,]
                {
                    { 1, 1f, null, 1, "Hit" },
                    { 2, 5f, null, 2, "Rap" },
                    { 3, 3f, null, 1, "Letniaczek" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[,]
                {
                    { 1, "Hity2022", 1, new DateTime(2022, 6, 12, 12, 35, 41, 938, DateTimeKind.Utc).AddTicks(2480) },
                    { 2, "Hity2021", 2, new DateTime(2021, 6, 12, 14, 35, 41, 938, DateTimeKind.Local).AddTicks(2490) }
                });

            migrationBuilder.InsertData(
                table: "MusicianTracks",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_IdMusicLabel",
                table: "Albums",
                column: "IdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTracks_IdMusician",
                table: "MusicianTracks",
                column: "IdMusician");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_IdAlbum",
                table: "Tracks",
                column: "IdAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianTracks");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "MusicLabels");
        }
    }
}
