function createAndPrintTowns(input){
    let listOfTowns = [];
    for(let i = 0; i < input.length; i++){
        const [name, latitude, longitude] = input[i].split(' | ');
        const town = {
            town: name,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        }
        listOfTowns.push(town);
    }
    listOfTowns.forEach(town => {
        console.log(town);
    });
}
createAndPrintTowns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);