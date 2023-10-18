using CmacPartnerApi.Model;

namespace CmacPartnerApi;

public static class Routes
{
    public static WebApplication MapRoutes(this WebApplication app)
    {
        app.MapPost("/quote", GetQuote)
            .WithParameterValidation()
            .Produces<QuoteResponse>();

        app.MapGroup("/book")
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

    private static IResult GetQuote(QuoteRequest model)
    {
        // is the vehicle type requested, supported?
        // are we fully booked?
        // get the nearest vehicle
        // calculate a price
        return Results.Ok(new QuoteResponse
        {
            Eta = 610,
            Price = new Price
            {
                Type = PriceTypes.JourneyNet,
                Amount = 2850,
                Currency = PriceCurrencies.GBP,
            },
        });
    }

    private static IResult CreateBooking(BookRequest model)
    {
        return Results.Ok(new BookResponse
        {
            Id = Guid.NewGuid().ToString(),
            Eta = 610,
        });
    }

    private static IResult GetBooking(string id)
    {
        // retrieve booking by id
        return Results.Ok(new FullBookResponse
        {
            Id = id,
            VehicleType = "Saloon",
            Pickup = DateTimeOffset.Now.AddHours(4),
            Reference = "YourReference",
            Status = "DroppedOff",
            Stops = new[]
            {
                new Address
                {
                    Address1 = "17 The Street",
                    Address2 = "Over here",
                    Region = "Testchester",
                    Postcode = "AA1 1AA",
                    Country = "England",
                    IsoCountry = "GB",
                    Lat = 52.42553f,
                    Lng = -1.2974f,
                },
                new Address
                {
                    Address1 = "45 Destination Avenue",
                    Postcode = "SH4 6WE",
                    Country = "England",
                    IsoCountry = "GB",
                    Lat = 53.9173f,
                    Lng = -1.3254f,
                },
            },
            PaxCount = 2,
            Passenger = new PassengerType
            {
                Name = "Mr Tester",
                Number = "0123456789",
            },
            Vehicle = new VehicleType
            {
                Vrn = "ABC1 1AA",
                Description = "White Toyata Prius",
                Driver = new Driver
                {
                    Name = "Mr Driver",
                    Number = "987654321",
                    Image = "https://driversimages.com/abcdefgh",
                },
            },
            Lat = 52.42553f,
            Lng = -1.2974f,
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
                    Type = PriceTypes.Waiting,
                    Amount = 1000,
                    Currency = PriceCurrencies.GBP,
                },
                new Price
                {
                    Type = PriceTypes.Parking,
                    Amount = 250,
                    Currency = PriceCurrencies.GBP,
                },
            },
        });
    }

    private static IResult UpdateBooking(string id, BookRequest model)
    {
        // retrieve booking by id
        // make updates/changes and notify driver if necessary
        // return new booking id (if it has to change) otherwise the same id
        return Results.Ok(new BookResponse
        {
            Id = Guid.NewGuid().ToString(),
            Eta = 610,
        });
    }

    private static IResult CancelBooking(string id)
    {
        // retrieve booking by id and cancel
        // return an empty body with success HTTP code
        return Results.Ok();
    }
}