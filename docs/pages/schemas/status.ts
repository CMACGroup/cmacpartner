import { z } from "zod";
import {
  vehicleTypeValues,
  priceSchema,
  stopSchema,
  statusTypeValues,
} from "./common";

const statusResponseSchema = z
  .object({
    id: z.string().max(50).min(5),
    pickup: z.string().datetime({ offset: true }),
    stops: z
      .array(stopSchema)
      .refine((x) => x && x.length > 1 && x.length < 10, {
        message: "There must be at least 2 stops and no more than 10",
      }),
    status: z.enum(statusTypeValues),
    paxCount: z.number().int().gt(0).lte(99),
    reference: z.string().max(50),
    passenger: z
      .object({
        name: z.string().max(255),
        number: z.string().max(50).optional(),
      })
      .optional(),
    prices: z.array(priceSchema).optional(),
    lat: z.number().gte(-90).lte(90).optional(),
    lng: z.number().gte(-180).lte(180).optional(),
    vehicle: z.object({
      type: z.enum(vehicleTypeValues),
      attributes: z.array(z.string()).optional(),
      vrn: z.string().max(20),
      description: z.string().max(255),
      driver: z
        .object({
          name: z.string().max(255),
          number: z.string().max(50).optional(),
          image: z.string().max(1000).optional(),
        })
        .optional(),
    }),
  })
  .strict();

type StatusResponse = z.infer<typeof statusResponseSchema>;

export { statusResponseSchema, StatusResponse };
