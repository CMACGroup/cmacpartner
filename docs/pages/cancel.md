# Cancel

This request is used to cancel a booking immediately. There is the possibility that a booking cannot be cancelled e.g. the driver has already arrived etc, in which case the response should indicate failure (HTTP status 409) with a description of why. CMAC will then attempt to cancel it manually by calling. There is also the potential that charges are already incurred if the driver is stood down in which case the response should return success and a body included the final/full charges.

## Details

|             |                                                  |
| ----------- | ------------------------------------------------ |
| Url         | https://_\<your custom url\>_**/booking**/\<id\> |
| Method      | DELETE                                           |
| HTTP Header | Accept: application/json                         |
| Format      | JSON                                             |
|             |                                                  |

## Payloads

### Response

```json
{
  "id": "Unique id",
  "pickup": "2023-02-01T18:30:00+01:00",
  "stops": [
    {
      "pickupPoint": "Round he back of the main building",
      "address1": "17 The Street",
      "address2": "Over here",
      "town": "Testsville",
      "region": "Testchester",
      "postcode": "AA1 1AA",
      "country": "England",
      "isoCountry": "GB",
      "lat": 52.42553,
      "lng": -1.2974
    },
    {
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
    }
  ],
  "status": "Cancelled",
  "paxCount": 2,
  "reference": "ABC123:XYZ456",
  "passenger": {
    "name": "Mr McTestit",
    "number": "0778899955"
  },
  "prices": [
    {
      "type": "JourneyNet",
      "description": null,
      "amount": 3250,
      "currency": "GBP"
    },
    {
      "type": "Waiting",
      "description": "15 minutes",
      "amount": 800,
      "currency": "GBP"
    }
  ],
  "lat": 53.9173,
  "lng": -1.3254,
  "vehicle": {
    "type": "Saloon",
    "vrn": "AB1 1AA",
    "description": "White Toyota Prius",
    "driver": {
      "name": "Tester Driver Person",
      "number": "07912345678",
      "image": "https://www.driverpictures.com/123456789"
    }
  }
}
```
