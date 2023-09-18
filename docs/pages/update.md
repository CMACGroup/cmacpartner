# Update

## Details

|             |                                                |
| ----------- | ---------------------------------------------- |
| Url         | https://_\<your custom url\>_**/update**/\<id> |
| Method      | PUT                                            |
| HTTP Header | Accept: application/json                       |
| Format      | JSON                                           |
|             |                                                |

## Payloads

### Request

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
  "vehicleType": "Saloon",
  "paxCount": 2,
  "reference": "ABC123:XYZ456",
  "price": {
    "type": "JourneyNet",
    "description": null,
    "amount": 3250,
    "currency": "GBP"
  },
  "distance": 5164,
  "notes": "Meet round by the side entrance"
}
```

### Response

```json
{
  "id": "any unique id",
  "eta": 620,
  "vehicleType": "Saloon"
}
```
