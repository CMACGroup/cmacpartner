# Update

After a request to `book` a journey has been made, there may be later alterations, particularly for pre-booked journeys, that need to communicated. This endpoint allows us to make those changes and should replace the details of the booking at the Id specified.

## Details

|             |                                                |
| ----------- | ---------------------------------------------- |
| Url         | https://_\<your custom url\>_**/update**/\<id> |
| Method      | PUT                                            |
| HTTP Header | Content-Type: application/json                 |
| HTTP Header | Accept: application/json                       |
| Format      | JSON                                           |
|             |                                                |

## Payloads

### Request

```json
{
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
  "status": "Booked",
  "vehicle": {
    "type": "Saloon",
    "attributes": ["Pets"]
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
    "currency": "GBP"
  },
  "distance": 5164,
  "notes": "Meet round by the side entrance",
  "flightNumber": "BA1234"
}
```

### Response

```json
{
  "id": "any unique id",
  "eta": 620
}
```
