# Reference Data

There are a number of `types` that are predefined lists of values that will either not change or will change very infrequently and pre-communicated. These are:

## Vehicle Types

| Value    | Description                                                                                                         |
| -------- | ------------------------------------------------------------------------------------------------------------------- |
| Saloon   | 4 seater 'standard' car                                                                                             |
| WAV      | Vehicle capable of carrying an electric wheelchair that cannot be folded. Also needs to carry at least 4 passengers |
| MPV      | Can carry up top 8 passengers (without luggage)                                                                     |
| Minibus  | Can carry up to 10 passengers                                                                                       |
| Exec     | Executive saloon vehicle with capacity of 4 passengers                                                              |
| BlackCab | Hackney carriage with capacity for up to 5 passengers                                                               |
|          |                                                                                                                     |

## Vehicle Attributes

While the type of vehicle may not change, it is useful to be able to specify additional requirements/attributes that the vehicle should meet

| Value    | Description                                          |
| -------- | ---------------------------------------------------- |
| Electric | The vehicle is 100% electric (not hybrid)            |
| Hybrid   | A combined electric and combustion engine            |
| Pets     | The vehicle will transport passengers and their pets |
|          |                                                      |

## Price Types

To enable maximum flexibility each booking can contain one or more `Prices`. Each of these entries is identified with a type, description, amount and currency. Each type of price should only exist once per booking but there can be multiple price entries per booking.

| Value         | Description                                                                                                                                                                 |
| ------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| JourneyNet    | The price, net of any tax, associated with the travel/journey. Often referred to as the "Fare"                                                                              |
| JourneyTax    | The tax element that relates to the journey performed. Whether this is included depends on a number of factors including whether the operator is registered for tax/VAT etc |
| Waiting       | The amount to be charged waiting for a passenger at a location. The number of minutes can be included in the Price description                                              |
| GreenFee      | Some locations employ a clean air or ULEZ zone and therefore charge vehicles who enter it                                                                                   |
| Toll          | The toll fee paid to travel on some roads                                                                                                                                   |
| Parking       | Any parking charges incurred by the driver/vehicle                                                                                                                          |
| MeetAndGreet  | Additional amount that is charged if the driver should leave the vehicle to meet the passenger                                                                              |
| Soilage       | If the driver/operator has to charge extra for cleaning of a vehicle as a result of a passenger                                                                             |
| LeadMiles     | The additional distance to the pickup location                                                                                                                              |
| BookingFee    | A charge per booking that is added                                                                                                                                          |
| Miscellaneous | A catch all rarely used but allows for capture of additional 'one off' charges                                                                                              |
|               |                                                                                                                                                                             |

## Currency

Wherever a currency is used it should be the 3 character ISO reference value e.g. GBP (Great British Pounds), EUR (Euro) etc

## Booking Status

| Value      | Description                                                                                                                                        |
| ---------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| Booked     | The initial state of a booking when it has been received but not assigned to a driver/vehicle                                                      |
| Dispatched | The vehicle is on it's way to the pickup location                                                                                                  |
| Arrived    | The vehicle has arrived at the pickup location but the passenger is yet to be picked up                                                            |
| PickedUp   | The passenger has boarded the vehicle and it is on it's way to the destination/stops                                                               |
| DroppedOff | The vehicle has finished all the stops in the booking request and the passenger has left the vehicle. (FINAL STATE)                                |
| Cancelled  | The booking is/has been cancelled by the operator and will not be fulfilled. (FINAL STATE)                                                         |
| NoShow     | The passenger did not arrive at the pickup location or could not be found so the vehicle has left and the booking has been finished. (FINAL STATE) |
|            |                                                                                                                                                    |

## Common Elements

### Price

#### Example

```json
"type": "Waiting",
"description": null,
"amount": 850,
"currency": "GBP",
"attributes": [{ "key": "Minutes", "value": "15" }]
```

#### Schema

| Element     | Description                                                                                                                                                                       |
| ----------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| type        | Required. One of [the predefined price types](#price-types)                                                                                                                       |
| description | Optional. String description. Max length 255                                                                                                                                      |
| amount      | Required. Integer value of price amount e.g. pence for GBP or cents for EUR                                                                                                       |
| currency    | Required. 3 character ISO string as described [here](#currency)                                                                                                                   |
| attributes  | Optional. Array of objects containing key/value string pairs used to communicate additional info around the price if required e.g. number of lead miles or number of wait minutes |
|             |                                                                                                                                                                                   |

### Address

#### Example

```json
"pickupPoint": null,
"address1": "45 Destination Avenue",
"address2": "Over there",
"town": "Somewhere else",
"region": null,
"postcode": "SH4 6WE",
"country": "England",
"isoCountry": "GB",
"lat": 53.9173,
"lng": -1.3254
```

#### Schema

| Element     | Description                                                                              |
| ----------- | ---------------------------------------------------------------------------------------- |
| pickupPoint | Optional. String with instructions on where the passenger will be located. Max length 50 |
| address1    | Required. First line of the address. Max length 255                                      |
| address2    | Optional. Multi-line string. Max length 255                                              |
| town        | Optional. City/town name. Max length 50                                                  |
| region      | Optional. Region/county/area. Max length 50                                              |
| postcode    | Optional. Postal code. Max length 20                                                     |
| country     | Required. Country name. Max length 50                                                    |
| isoCountry  | Required. 2 character ISO country code e.g. GB or FR. Max length 2                       |
| lat         | Required. Double floating point numeric value                                            |
| lng         | Required. Double floating point numeric value                                            |
|             |                                                                                          |

### Vehicle

#### Example

```json
"type": "Saloon",
"attributes": []
```

#### Schema

| Element    | Description                                                                                                   |
| ---------- | ------------------------------------------------------------------------------------------------------------- |
| type       | Required. One of [the predefined vehicle types](#vehicle-types)                                               |
| attributes | Optional. Array of strings containing one or more of [the predefined vehicle attributes](#vehicle-attributes) |
|            |                                                                                                               |
