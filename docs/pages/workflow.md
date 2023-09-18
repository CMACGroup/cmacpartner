# Workflow

The **"normal"** workflow for a booking should be:

Quote -> Book -> Update

or

Quote -> Book -> Cancel

unless the operator cancels it their side and therefore sends the status Cancelled or NoShow.

## Updates

If possible the operator system should send updates to https://cmacpartner.cmacgroup.com/updates containing the following payload. If it is not possible to automate the sending of updates then CMAC will request an update for a booking at least once per minute. Updates can be sent every time there is a "status" change to a booking or simply when the GPS location of the vehicle is updated.

### Payload

```json
{
  "id": "Your unique id",
  "dateTime": "2023-06-05T16:03:02Z",
  "status": "Arrived",
  "prices": [
    {
      "type": "JourneyNet",
      "description": null,
      "amount": 3250,
      "currency": "GBP",
      "attributes": [{ "key": "Minutes", "value": "15" }]
    },
    {
      "type": "Waiting",
      "description": "15 minutes waiting",
      "amount": 800,
      "currency": "GBP",
      "attributes": []
    }
  ],
  "lat": 53.9173,
  "lng": -1.3254,
  "vehicle": {
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

CMAC will respond with a 200 OK success upon receipt of an update but they are processed in the background, so even if the booking cannot be found, no error is returned.

## HTTP

When implementing the endpoints you should adhere to the HTTP standard https://www.rfc-editor.org/rfc/rfc2616 but most importantly:

- Requests should return the appropriate response code

| Code | Description           | Used when                                                                                                                              |
| ---- | --------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| 200  | Success               | The request succeeded and the necessary updates were made                                                                              |
| 400  | Bad Request           | There was something in the payload that was invalid                                                                                    |
| 409  | Conflict              | The request could not be actioned because it violated internal rules e.g. cancellation when the driver has already been dispatched etc |
| 500  | Internal Server Error | An error occurred in the operators system that prevented the request being actioned                                                    |
|      |                       |                                                                                                                                        |

- You should not return a success code when there is a problem even if the payload contains details of the error. Where an error does occur however it is useful to contain details of the problem e.g.

Response contents for a 400 status

```json
{
  "error": "Departure date is in the past"
}
```

or

Response contents for a 409 status

```json
{
  "error": "There are no vehicles available"
}
```
