function makeDictionary(jsonArray){
    class Term{
        constructor(name, definition){
            this.name = name;
            this.definition = definition;
        }
        printTerm(){
            console.log(`Term: ${this.name} => Definition: ${this.definition}`);
        }
    }

    const terms = [];
    jsonArray.forEach(string => {
        const termName = Object.keys(JSON.parse(string))[0];
        const definition = Object.values(JSON.parse(string))[0];
        const term = new Term(termName, definition);

        if(terms.includes(term)){
            terms.find(term => term.name === termName).definition = definition;
        } else{
            terms.push(term);
        }
    });

    terms.sort((a, b) => a.name.localeCompare(b.name));
    terms.forEach(term => term.printTerm());
}
makeDictionary([
    '{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}',
    '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."}',
    '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."} ',
    '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."} ',
    '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."} ']
);