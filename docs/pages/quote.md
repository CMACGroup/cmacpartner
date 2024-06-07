# Quote

Used to obtain estimated prices (per operator) and optional ETA if you can cover a booking with the specified details. If you cannot cover then just return an empty array.

## Details

|             |                                         |
| ----------- | --------------------------------------- |
| Url         | https://_\<your custom url\>_**/quote** |
| Method      | POST                                    |
| HTTP Header | Content-Type: application/json          |
| HTTP Header | Accept: application/json                |
| Format      | JSON                                    |
|             |                                         |

## Examples

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
  "distance": 5164,
  "vehicle": {
    "type": "Saloon",
    "attributes": []
  },
  "paxCount": 2
}
```

### Response

```json
{
  "quotes": [
    {
      "operatorId": "123456789",
      "eta": 620,
      "price": {
        "type": "JourneyNet",
        "amount": 3250,
        "currency": "GBP"
      }
    }
  ]
}
```

## Schema

### Request

| Element  | Description                                                                                                                                                                                                                                 |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| pickup   | Required. ISO formatted date time string including the daylight saving offset e.g. 2023-06-01T15:25:00+01:00                                                                                                                                |
| stops    | Required. An array of [addresses](/pages/referencedata#address) in the order they should be visited. The first is assumed to be the pickup address and the last the destination but there can be many via/intermediate addresses in between |
| distance | Required. An integer number describing the number of metres for the whole journey including via addresses                                                                                                                                   |
| vehicle  | The type and attributes of the required vehicle as per [the description](/pages/referencedata#vehicle)                                                                                                                                      |
| paxCount | The number of passengers. Min 1, Max 100                                                                                                                                                                                                    |
|          |                                                                                                                                                                                                                                             |

### Response

| Element | Description                                                                                            |
| ------- | ------------------------------------------------------------------------------------------------------ |
| eta     | Optional: The estimated number of seconds it is expected for the vehicle to get to the pickup location |
| price   | Required. The estimated [JourneyNet price](/pages/referencedata#price)                                 |
|         |                                                                                                        |
