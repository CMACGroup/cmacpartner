import { z } from "zod";
import { vehicleTypeValues, priceSchema, stopSchema } from "./common";

const updateRequestSchema = z
  .object({
    pickup: z.string().datetime({ offset: true }),
    stops: z
      .array(stopSchema)
      .refine((x) => x && x.length > 1 && x.length < 10, {
        message: "There must be at least 2 stops and no more than 10",
      }),
    vehicleType: z.enum(vehicleTypeValues),
    paxCount: z.number().int().gt(0).lte(99),
    reference: z.string().max(50),
    passenger: z
      .object({
        name: z.string().max(255),
        number: z.string().max(50).optional(),
      })
      .optional(),
    price: priceSchema,
    distance: z.number().int(),
    notes: z.string().max(255).optional(),
  })
  .strict();

type UpdateRequest = z.infer<typeof updateRequestSchema>;

const updateResponseSchema = z
  .object({
    id: z.string().max(50).min(5),
    eta: z.number().int().optional(),
  })
  .strict();

type UpdateResponse = z.infer<typeof updateResponseSchema>;

const sampleUpdateRequest: string = `{
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
    "vehicleType": "Saloon",
    "paxCount": 2,
    "reference": "ABC123:XYZ456",
    "passenger": {
      "name": "Mr McTestit",
      "number": "0778899955"
    },
    "price": {
      "type": "JourneyNet",
      "amount": 3250,
      "currency": "GBP"
    },
    "distance": 5164,
    "notes": "Meet round by the side entrance"    
  }`;

export {
  updateRequestSchema,
  UpdateRequest,
  updateResponseSchema,
  UpdateResponse,
  sampleUpdateRequest,
};
