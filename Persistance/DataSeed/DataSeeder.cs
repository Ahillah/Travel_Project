using DomainLayer.Models.Tours;
using DomainLayer.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.DataSeed
{
    public class DataSeeder(ApplicationDbContext _dbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try
            {
                // === Tours ===
                string toursPath = @"D:\Basma\Back end\Travelo_Project-master\Travelo_Project-master\Backend\Persistance\DataSeed\Data\tours.json";
                string toursData = File.ReadAllText(toursPath);
                var tours = JsonSerializer.Deserialize<List<Tours>>(toursData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (tours != null && tours.Any())
                {
                    foreach (var t in tours)
                    {
                        t.Id = 0; // EF Core يولد Id جديد
                        _dbContext.Tours.Add(t);
                    }
                    _dbContext.SaveChanges();
                }

                // === TourDates ===
                string datesPath = @"D:\Basma\Back end\Travelo_Project-master\Travelo_Project-master\Backend\Persistance\DataSeed\Data\tourDates.json";
                if (File.Exists(datesPath))
                {
                    string datesData = File.ReadAllText(datesPath);
                    var tourDates = JsonSerializer.Deserialize<List<TourDate>>(datesData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (tourDates != null && tourDates.Any())
                    {
                        foreach (var d in tourDates)
                        {
                            d.Id = 0;
                            _dbContext.TourDates.Add(d);
                        }
                        _dbContext.SaveChanges();
                    }
                }

                // === TourItineraries ===
                string itinerariesPath = @"D:\Basma\Back end\Travelo_Project-master\Travelo_Project-master\Backend\Persistance\DataSeed\Data\itineraries.json";
                if (File.Exists(itinerariesPath))
                {
                    string itinerariesData = File.ReadAllText(itinerariesPath);
                    var itineraries = JsonSerializer.Deserialize<List<TourItinerary>>(itinerariesData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (itineraries != null && itineraries.Any())
                    {
                        foreach (var i in itineraries)
                        {
                            i.Id = 0;
                            _dbContext.TourItineraries.Add(i);
                        }
                        _dbContext.SaveChanges();
                    }
                }

                // === TourInclusions ===
                string inclusionsPath = @"D:\Basma\Back end\Travelo_Project-master\Travelo_Project-master\Backend\Persistance\DataSeed\Data\inclusions.json";
                if (File.Exists(inclusionsPath))
                {
                    string inclusionsData = File.ReadAllText(inclusionsPath);
                    var inclusions = JsonSerializer.Deserialize<List<TourInclusion>>(inclusionsData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (inclusions != null && inclusions.Any())
                    {
                        foreach (var inc in inclusions)
                        {
                            inc.Id = 0;
                            _dbContext.TourInclusions.Add(inc);
                        }
                        _dbContext.SaveChanges();
                    }
                }

                // === TourDestinations ===
                string destinationsPath = @"D:\Basma\Back end\Travelo_Project-master\Travelo_Project-master\Backend\Persistance\DataSeed\Data\tourDestinations.json";
                if (File.Exists(destinationsPath))
                {
                    string destinationsData = File.ReadAllText(destinationsPath);
                    var destinations = JsonSerializer.Deserialize<List<TourDestination>>(destinationsData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (destinations != null && destinations.Any())
                    {
                        foreach (var dest in destinations)
                        {
                            dest.TourId = 0;
                            _dbContext.TourDestinations.Add(dest);
                        }
                        _dbContext.SaveChanges();
                    }
                }

                Console.WriteLine("تم إضافة كل البيانات بنجاح!");
            }
            catch (Exception ex)
            {
                //TODO
            }
        }
    }
}
