# Workflow

The **"normal"** workflow for a booking should be:

Quote -> Book -> Update

or

Quote -> Book -> Cancel

unless the operator cancels it their side and therefore sends the status [Cancelled](/pages/referencedata#booking-status) or [NoShow](/pages/referencedata#booking-status).

## Multiple operators

There may be the requirement that a single integration between ourselves needs to target multiple operators. If this is the case, certain requests/responses allow for the passing of an `operatorId`. If there is only a single operator within your system, this property can be ignored/omitted. Note however that each of these individual operators will need creating in our system individually as they may need to invoice independently. If this is the case, please communicate the list of operators and their ids to our supply team [supplier.relations@cmacgroup.com](mailto:supplier.relations@cmacgroup.com).

## Updates and Hooks

If possible the operator system should send updates to https://cmacpartner.cmacgroup.com/updates containing the following payload. If it is not possible to automate the sending of updates then CMAC will request an update for a booking at least once per minute. Updates can be sent every time there is a "status" change to a booking or simply when the GPS location of the vehicle is updated.

### Payload

```json
{
  "id": "Your unique id",
  "pickup": "2023-02-01T18:30:00+01:00",
  "status": "Arrived",
  "prices": [
    {
      "type": "JourneyNet",
      "amount": 3250,
      "currency": "GBP"
    },
    {
      "type": "Waiting",
      "description": "15 minutes waiting",
      "amount": 800,
      "currency": "GBP",
      "attributes": [{ "key": "Minutes", "value": "15" }]
    }
  ],
  "lat": 53.9173,
  "lng": -1.3254,
  "vehicle": {
    "vrn": "ML123 3XX",
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

## HTTP Responses and Errors

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

## Support

If you have any questions that you would like to us to clarify you can send them to [support@cmacgroup.com](mailto:support@cmacgroup.com).
