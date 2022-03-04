﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entities.Models.Enums;

namespace MyDatabase.Seeding
{
    public class SeedingService
    {
        //Dependency Injection
        ApplicationDbContext db;
        public SeedingService(ApplicationDbContext context)
        {
            db = context;
        }

        //Implementation of Seeding Methods ex. public void SeedPackages()
        public void SeedPackages()
        {
            //Package Seeding
            Package p1 = new Package() { Title = "Beautiful Spain", Description = "Vacations at Barcelone", TripDate = new DateTime(2022, 5, 12), TripDuration = 4, Price = 476 };


            //Booking Seeding
            Booking b1 = new Booking() { PurchaseDate = new DateTime(2022, 02, 02) };
            db.Packages.Add(p1);
            db.Bookings.Add(b1);
            b1.Package = p1;
        
            //Photo Seeding
            Photo photosAthens = new Photo() { Destinations= Destinations.Athens, Url="https://3.bp.blogspot.com/-ZfIVrmoK0HA/XfsiM6oOIkI/AAAAAAABsfI/qwIuU7cz9ukjN2pw0wECSCR48Bulvf8IACK4BGAYYCw/s1600/Screenshot_5.jpg" };
            Photo photosBarcelona = new Photo() { Destinations = Destinations.Barcelona, Url= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdDk_JTBO1VJYeoHp3tnqs8XGkB7wfN9EY6Q&usqp=CAU" };
            Photo photosLondon = new Photo() { Destinations = Destinations.London, Url= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRvp5BzRDdhtlUNh7CGHYdVp_HFwDs_FOx-Ow&usqp=CAU" };
            Photo photosParis = new Photo() { Destinations = Destinations.Paris, Url = "https://c.pxhere.com/photos/3c/c2/eiffel_tower_paris-159.jpg!s1" };
            Photo PhotosRome = new Photo() { Destinations = Destinations.Rome, Url = "http://www.cosavisitarearoma.it/images/immagini_articoli/piazza-di-spagna.jpg" };
            db.Photos.Add(photosAthens);
            db.Photos.Add(photosBarcelona);
            db.Photos.Add(photosLondon);
            db.Photos.Add(photosParis);
            db.Photos.Add(PhotosRome);

            p1.Photos.Add(photosBarcelona);



            // Comment Seeding
            Comment com1 = new Comment() { CommentContent = "Excellent! Very good service from beginning to end" };
            Comment com2 = new Comment() { CommentContent = "Awesome support! Very much appreciated" };
            db.Comments.Add(com1);
            db.Comments.Add(com2);

            //Flight Seeding
            Flight f1 = new Flight() { CompanyName = "Aegean" };
            db.Flights.Add(f1);
            p1.Flight = f1;

            //Hotel Seeding
            Hotel h1 = new Hotel() { HotelName = "Saint-Roch", HotelStars = 2, Destinations = Destinations.Paris };
            db.Hotels.Add(h1);
            p1.Hotel= h1;

            db.SaveChanges();

        }

    }
}
