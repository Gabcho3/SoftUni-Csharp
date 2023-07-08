function convertToObject(jsonString){
    const person = JSON.parse(jsonString);
    for(const key of Object.keys(person)){
        console.log(`${key}: ${person[key]}`);
    }
}
convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');