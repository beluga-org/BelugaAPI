﻿// <auto-generated />
using System;
using BelugaAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BelugaAPI.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241123213826_chatTable")]
    partial class chatTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BelugaAPI.Core.Entities.AccessKey", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("access_key");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Chat", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("videoId")
                        .HasColumnType("text")
                        .HasColumnName("video_id");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("threadId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("userId", "videoId");

                    b.HasIndex("videoId");

                    b.ToTable("chat");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Translation", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("subtitleUrl")
                        .HasColumnType("text")
                        .HasColumnName("subtitle_url");

                    b.Property<string>("translationUrl")
                        .HasColumnType("text")
                        .HasColumnName("translation_url");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("videoId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("video_id");

                    b.HasKey("id");

                    b.HasIndex("videoId");

                    b.ToTable("translation");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.User", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Video", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("assistantExternalId")
                        .HasColumnType("text")
                        .HasColumnName("assistant_external_id");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("originalLanguage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_language");

                    b.Property<string>("originalName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_name");

                    b.Property<string>("originalUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("original_url");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("video");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.AccessKey", b =>
                {
                    b.HasOne("BelugaAPI.Core.Entities.User", "user")
                        .WithMany("accessKeys")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Chat", b =>
                {
                    b.HasOne("BelugaAPI.Core.Entities.User", "user")
                        .WithMany("chats")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BelugaAPI.Core.Entities.Video", "video")
                        .WithMany("chats")
                        .HasForeignKey("videoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");

                    b.Navigation("video");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Translation", b =>
                {
                    b.HasOne("BelugaAPI.Core.Entities.Video", null)
                        .WithMany("translations")
                        .HasForeignKey("videoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Video", b =>
                {
                    b.HasOne("BelugaAPI.Core.Entities.User", "user")
                        .WithMany("videos")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.User", b =>
                {
                    b.Navigation("accessKeys");

                    b.Navigation("chats");

                    b.Navigation("videos");
                });

            modelBuilder.Entity("BelugaAPI.Core.Entities.Video", b =>
                {
                    b.Navigation("chats");

                    b.Navigation("translations");
                });
#pragma warning restore 612, 618
        }
    }
}
