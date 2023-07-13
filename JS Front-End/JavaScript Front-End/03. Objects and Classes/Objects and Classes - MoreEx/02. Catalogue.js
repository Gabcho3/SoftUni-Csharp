function createCatalogue(input) {
  const catalogue = input.reduce((acc, curr) => {
    const [productName, productPrice] = curr.split(" : ");
    const product = {
      name: productName,
      price: productPrice,
    };
    acc.push(product);

    return acc;
  }, []);

  catalogue.sort((a, b) => a.name.localeCompare(b.name));

  let previousInitial = "";
  for (let i = 0; i < catalogue.length; i++) {
    const product = catalogue[i];
    const currInitial = product.name[0];

    if (currInitial != previousInitial) {
      console.log(currInitial);
    }
    console.log(`  ${product.name}: ${product.price}`);
    previousInitial = currInitial;
  }
}
createCatalogue([
  "Appricot : 20.4",
  "Fridge : 1500",
  "TV : 1499",
  "Deodorant : 10",
  "Boiler : 300",
  "Apple : 1.25",
  "Anti-Bug Spray : 15",
  "T-Shirt : 10",
]);
