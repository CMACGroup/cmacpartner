import { z } from "zod";
const vehicleTypeValues = [
  "Saloon",
  "WAV",
  "MPV",
  "Minibus",
  "Exec",
  "BlackCab",
] as const;

const priceTypeValues = [
  "JourneyNet",
  "JourneyTax",
  "Waiting",
  "GreenFee",
  "Toll",
  "Parking",
  "MeetAndGreet",
  "Soilage",
  "LeadMiles",
  "BookingFee",
  "Miscellaneous",
] as const;

const statusTypeValues = [
  "Booked",
  "Dispatched",
  "Arrived",
  "PickedUp",
  "DroppedOff",
  "Cancelled",
  "NoShow",
] as const;

const vehicleAttributeValues = ["Electric", "Hybrid", "Pets"] as const;

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

const priceSchema = z
  .object({
    type: z.enum(priceTypeValues),
    description: z.nullable(z.string().max(255).optional()),
    amount: z.number().int().gte(0).lte(99999999),
    currency: z.string().length(3).trim().toUpperCase(),
    attributes: z
      .object({
        attribute1: z.string(),
        attribute2: z.string(),
      })
      .optional(),
  })
  .strict();

export {
  vehicleTypeValues,
  priceTypeValues,
  stopSchema,
  priceSchema,
  vehicleAttributeValues,
  statusTypeValues,
};
