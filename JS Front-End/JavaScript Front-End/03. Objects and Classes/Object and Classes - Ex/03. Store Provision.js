function addStoreProvisions(stock, ordered){
    let allProducts = stock + ',' + ordered;
    allProducts = allProducts.split(',');

    let listOfProducts = {};
    for(let i = 0; i < allProducts.length - 1; i += 2){
        const product = allProducts[i];
        const quantity = Number(allProducts[i + 1]);

        if (listOfProducts.hasOwnProperty(product)){
            listOfProducts[product] += quantity;
        } else{
            listOfProducts[product] = quantity;
        }
    }
    for(const [product, quantity] of Object.entries(listOfProducts)){
        console.log(`${product} -> ${quantity}`);
    }
}
addStoreProvisions([
    'Chips', '5', 'CocaCola', '9', 'Bananas',
    '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7',
    'Tomatoes', '70', 'Bananas', '30'
    ]
    );