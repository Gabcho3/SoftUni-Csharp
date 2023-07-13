function createFlightShedule(input) {
  const flightsData = input[0];
  const flightsWithChangedStatus = input[1];
  const statusToPrint = input[2][0];

  const flights = getFlights(flightsData);
  changeFlightsStatus(flightsWithChangedStatus, flights);

  const flightsToPrint = flights.filter(
    (flight) => flight.Status === statusToPrint
  );
  flightsToPrint.forEach((flight) => console.log(flight.getFlight()));
}
function getFlights(flightsData) {
  return flightsData.reduce((acc, curr) => {
    const Sector = curr.substring(0, curr.indexOf(" "));
    const Destination = curr.substring(curr.indexOf(" ") + 1);
    const flight = {
      Sector,
      Destination,
      Status: "Ready to fly",
      getFlight() {
        return `{ Destination: '${this.Destination}', Status: '${this.Status}' }`;
      },
    };
    acc.push(flight);

    return acc;
  }, []);
}
function changeFlightsStatus(flightsWithChangedStatus, flights) {
  return flightsWithChangedStatus.forEach((element) => {
    const [sector, status] = element.split(" ");
    const currFlight = flights.find((flight) => flight.Sector === sector);
    if (currFlight != undefined) {
      currFlight.Status = status;
    }
  });
}
createFlightShedule([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK430 Cancelled",
  ],
  ["Cancelled"],
]);

createFlightShedule([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK330 Cancelled",
  ],
  ["Ready to fly"],
]);
