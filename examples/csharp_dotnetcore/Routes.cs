using CmacPartnerApi.Model;

namespace CmacPartnerApi;

public static class Routes
{
    public static WebApplication MapRoutes(this WebApplication app)
    {
        app.MapPost("/quote", GetQuote)
            .WithParameterValidation()
            .Produces<QuoteResponse>();

        app.MapGroup("/booking")
            .MapBookingApi()
            .WithParameterValidation();

        return app;
    }

    private static RouteGroupBuilder MapBookingApi(this RouteGroupBuilder group)
    {
        group.MapPost("/", CreateBooking)
            .Produces<BookResponse>();

        group.MapGet("/{id}", GetBooking)
            .Produces<FullBookResponse>();

        group.MapPut("/{id}", UpdateBooking);

        group.MapDelete("/{id}", CancelBooking);

        return group;
    }
    
    private static void GetQuote(QuoteRequest model)
    {
        // is the vehicle type requested, supported?
        // are we fully booked?
        // get the nearest vehicle
        // calculate a price
        Results.Ok(new QuoteResponse
        {
            Eta = 610,
            Price = new Price
            {
                Type = PriceTypes.JourneyNet,
                Amount = 2850,
                Currency = PriceCurrencies.GBP,
            },
            VehicleType = VehicleTypes.Saloon,
        });
    }

    private static void CreateBooking(BookRequest model)
    {
        Results.Ok(new BookResponse
        {
            Id = Guid.NewGuid().ToString(),
            Eta = 610,
        });
    }

    private static void GetBooking(string id)
    {
        // retrieve booking by id
        Results.Ok(new FullBookResponse
        {
            Id = id,
            VehicleType = VehicleTypes.Saloon,
            Pickup = DateTimeOffset.Now.AddHours(4),
            Notes = "Some special notes",
            Reference = "YourReference",
            Status = "DROPPEDOFF",
            Stops = new[] { new Address(), new Address() },
            PaxCount = 2,
            PaxName = "Mr Tester",
            PaxPhone = "0123456789",
            Driver = new Driver
            {
                Name = "Mr Driver",
                Phone = "987654321",
                Image = "https://driversimages.com/abcdefgh",
                VehicleDescription = "White Toyata Prius",
                VehicleNumber = "ABC1 1AA",
                Lat = 51.424f,
                Lng = -1.0165f,
            },
            Prices = new[]
            {
                new Price
                {
                    Type = PriceTypes.JourneyNet,
                    Amount = 2850,
                    Currency = PriceCurrencies.GBP,
                },
                new Price
                {
                    Type = PriceTypes.JourneyTax,
                    Amount = 150,
                    Currency = PriceCurrencies.GBP,
                },
                new Price
                {
                    Type = PriceTypes.WaitingNet,
                    Amount = 1000,
                    Currency = PriceCurrencies.GBP,
                },
                new Price
                {
                    Type = PriceTypes.WaitingTax,
                    Amount = 0,
                    Currency = PriceCurrencies.GBP,
                },
                new Price
                {
                    Type = PriceTypes.ParkingNet,
                    Amount = 250,
                    Currency = PriceCurrencies.GBP,
                },
            },
        });
    }

    private static void UpdateBooking(string id, BookRequest model)
    {
        // retrieve booking by id
        // make updates/changes and notify driver if necessary
        Results.Ok();
    }

    private static void CancelBooking(string id)
    {
        // retrieve booking by id and cancel
        Results.Ok();
    }
}