import { z } from "zod";
const vehicleTypeValues = [
  "Saloon",
  "WAV",
  "MPV",
  "Minibus",
  "Exec",
  "BlackCab",
] as const;

const stopSchema = z
  .object({
    pickupPoint: z.nullable(z.string().max(255).optional()),
    address1: z.string().max(255),
    address2: z.nullable(z.string().max(255).optional()),
    town: z.nullable(z.string().max(255).optional()),
    region: z.nullable(z.string().max(255).optional()),
    postcode: z.string().max(20),
    country: z.nullable(z.string().max(50).optional()),
    isoCountry: z.string().length(2).trim().toUpperCase(),
    lat: z.number().gte(-90).lte(90),
    lng: z.number().gte(-180).lte(180),
  })
  .strict();

const quoteSchema = z
  .object({
    pickup: z.string().datetime({ offset: true }),
    stops: z
      .array(stopSchema)
      .refine((x) => x && x.length > 1 && x.length < 10, {
        message: "There must be at least 2 stops and no more than 10",
      }),
    distance: z.number().int(),
    vehicle: z.object({
      "type:": z.enum(vehicleTypeValues),
      attributes: z.array(z.string().max(50)),
    }),
    paxCount: z.number().int().gt(0).lte(99),
  })
  .strict();

type Quote = z.infer<typeof quoteSchema>;

const sampleQuote: string = `{
  "pickup": "2023-02-01T18:30:00+01:00",
  "stops": [
    {
      "pickupPoint": "Round the back of the main building",
      "address1": "17 The Street",
      "address2": "Over here",
      "region": "Testchester",
      "postcode": "AA1 1AA",
      "country": "England",
      "isoCountry": "GB",
      "lat": 52.42553,
      "lng": -1.2974
    },
    {
      "address1": "45 Destination Avenue",
      "address2": "Over there",
      "town": "Somewhere else",
      "postcode": "SH4 6WE",
      "country": "England",
      "isoCountry": "GB",
      "lat": 53.9173,
      "lng": -1.3254
    }
  ],
  "distance": 5164,
  "vehicle": {
    "type:": "Saloon",
    "attributes": []
  },
  "paxCount": 2
}`;
export { quoteSchema, Quote, sampleQuote };
