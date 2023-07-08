function printCityInfo(city){
    Object.entries(city).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}
printCityInfo(
    {
        name: "Plovdiv",
        area: 389,
        population: 1162358,
        country: "Bulgaria",
        postCode: "4000"
    }
);