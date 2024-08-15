﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Said_Store.Infrastructure.Data;

#nullable disable

namespace Said_Store.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Said_Store.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            Description = "A classic novel of the Roaring Twenties.",
                            Genre = "Fiction",
                            Price = 10.99m,
                            Title = "The Great Gatsby",
                            Year = 1925
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            Description = "A novel of warmth and humor despite dealing with serious issues of race and rape.",
                            Genre = "Fiction",
                            Price = 7.99m,
                            Title = "To Kill a Mockingbird",
                            Year = 1960
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            Description = "A novel depicting a totalitarian society controlled by Big Brother.",
                            Genre = "Adventure",
                            Price = 8.99m,
                            Title = "1984",
                            Year = 1949
                        },
                        new
                        {
                            Id = 4,
                            Author = "Herman Melville",
                            Description = "A seafaring adventure about obsession and revenge.",
                            Genre = "Adventure",
                            Price = 11.50m,
                            Title = "Moby Dick",
                            Year = 1851
                        },
                        new
                        {
                            Id = 5,
                            Author = "Leo Tolstoy",
                            Description = "A historical novel that chronicles the French invasion of Russia.",
                            Genre = "Historical",
                            Price = 12.99m,
                            Title = "War and Peace",
                            Year = 1869
                        },
                        new
                        {
                            Id = 6,
                            Author = "Jane Austen",
                            Description = "A romantic novel that critiques the British landed gentry at the end of the 18th century.",
                            Genre = "Romance",
                            Price = 9.99m,
                            Title = "Pride and Prejudice",
                            Year = 1813
                        },
                        new
                        {
                            Id = 7,
                            Author = "J.D. Salinger",
                            Description = "A story about teenage angst and alienation.",
                            Genre = "Fiction",
                            Price = 6.99m,
                            Title = "The Catcher in the Rye",
                            Year = 1951
                        },
                        new
                        {
                            Id = 8,
                            Author = "J.R.R. Tolkien",
                            Description = "A fantasy novel and children's book about Bilbo Baggins's quest.",
                            Genre = "Fantasy",
                            Price = 8.50m,
                            Title = "The Hobbit",
                            Year = 1937
                        },
                        new
                        {
                            Id = 9,
                            Author = "Fyodor Dostoevsky",
                            Description = "A novel that explores the psychological effects of crime and punishment.",
                            Genre = "Philosophical",
                            Price = 10.75m,
                            Title = "Crime and Punishment",
                            Year = 1866
                        },
                        new
                        {
                            Id = 10,
                            Author = "Homer",
                            Description = "An epic poem about the journey of Odysseus back home after the Trojan War.",
                            Genre = "Fantasy",
                            Price = 14.00m,
                            Title = "The Odyssey",
                            Year = -800
                        });
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.Order", b =>
                {
                    b.HasOne("Said_Store.Domain.Entities.Buyer", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Said_Store.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Said_Store.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.Buyer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Said_Store.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
