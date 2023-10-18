import { z } from "zod";
import {
  vehicleTypeValues,
  stopSchema,
  vehicleAttributeValues,
  priceSchema,
} from "./common";
const quoteRequestSchema = z
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
      attributes: z.array(z.enum(vehicleAttributeValues)),
    }),
    paxCount: z.number().int().gt(0).lte(99),
  })
  .strict();

type QuoteRequest = z.infer<typeof quoteRequestSchema>;

const quoteResponseSchema = z
  .object({
    eta: z.number().int().optional(),
    price: priceSchema,
  })
  .strict();

type QuoteResponse = z.infer<typeof quoteResponseSchema>;

const sampleQuoteRequest: string = `{
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

export {
  quoteRequestSchema,
  QuoteRequest,
  quoteResponseSchema,
  QuoteResponse,
  sampleQuoteRequest,
};
