function createGarages(input) {
  const garages = input.reduce((acc, curr) => {
    let [garageNumber, keysAndValues] = curr.split(" - ");
    garageNumber = `Garage № ${garageNumber}`;

    const splitted = keysAndValues.split(", ");

    const car = {};
    splitted.forEach((data) => {
      const [key, value] = data.split(": ");
      car[key] = value;
    });

    if (!acc.hasOwnProperty(garageNumber)) {
      acc[garageNumber] = [];
    }

    acc[garageNumber].push(car);
    return acc;
  }, {});

  printGaragesInfo(garages);
}
function printGaragesInfo(garages) {
  for (const garage in garages) {
    console.log(garage);

    for (const cars of garages[garage]) {
      const keysAndValues = Object.entries(cars);

      let output = [];
      keysAndValues.forEach(([key, value]) => {
        output.push(key + " - " + value);
      });

      console.log("--- " + output.join(", "));
    }
  }
}
createGarages([
  "1 - color: blue, fuel type: diesel",
  "1 - color: red, manufacture: Audi",
  "2 - fuel type: petrol",
  "4 - color: dark blue, fuel type: diesel, manufacture: Fiat",
]);
