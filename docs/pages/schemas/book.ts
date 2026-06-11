import { z } from "zod";
import {
    meetAndGreetSchema,
    priceSchema,
    stopSchema,
    vehicleTypeValues,
} from "./common";

const bookRequestSchema = z
    .object({
        operatorId: z.string().max(50).optional(),
        pickup: z.string().datetime({ offset: true }),
        stops: z
            .array(stopSchema)
            .refine((x) => x && x.length > 1 && x.length < 10, {
                message: "There must be at least 2 stops and no more than 10",
            }),
        vehicle: z.object({
            type: z.enum(vehicleTypeValues),
            attributes: z.array(z.string()).optional(),
        }),
        paxCount: z.number().int().gt(0).lte(99),
        reference: z.string().max(50),
        passenger: z
            .object({
                name: z.string().max(255),
                number: z.string().max(50).optional(),
            })
            .optional(),
        price: priceSchema,
        extras: z.array(priceSchema).nullable().optional(),
        distance: z.number().int(),
        notes: z.string().max(255).optional(),
        flightNumber: z.string().max(255).optional(),
        meetAndGreet: meetAndGreetSchema.nullable().optional(),
        attributes: z
            .object({
                attribute1: z.string(),
                attribute2: z.string(),
            })
            .optional(),
    })
    .strict();

type BookRequest = z.infer<typeof bookRequestSchema>;

const bookResponseSchema = z
    .object({
        id: z.string().max(50).min(5),
        eta: z.number().int().optional(),
    })
    .strict();

type BookResponse = z.infer<typeof bookResponseSchema>;

const sampleBookRequest: string = `{
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
    "vehicle": {
      "type": "Saloon",
      "attributes": []
    },
    "paxCount": 2,
    "reference": "ABC123:XYZ456",
    "passenger": {
      "name": "Mr McTestit",
      "number": "0778899955"
    },
    "price": {
      "type": "JourneyNet",
      "amount": 3250,
      "currency": "GBP",
      "attributes" : {
        "attribute1" : "Value1",
        "attribute2" : "Value2"
      }
    },
    "extras": [
      {
        "type": "MeetAndGreet",
        "description": "Meet and Greet",
        "amount": 1500,
        "currency": "GBP",
        "attributes" : {
            "attribute1" : "Value1",
            "attribute2" : "Value2"
        }
      }
    ],
    "distance": 5164,
    "notes": "Meet round by the side entrance",
    "flightNumber": "BA1234",
    "attributes": {
      "attribute1": "Value1",
      "attribute2": "Value2"
    },
    "meetAndGreet": {
      "pickUpPoint": "By the counter in the arrivals hall",
      "waitingTimeMinutesIncluded": 30
    },
  }`;

export {
    BookRequest,
    bookRequestSchema,
    BookResponse,
    bookResponseSchema,
    sampleBookRequest,
};
