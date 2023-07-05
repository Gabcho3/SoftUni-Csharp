const structure = {
    1: (letter1, letter2) => `**${letter1}${letter2}**`,
    2: (letter1, letter2) => `*${letter1}--${letter2}*`,
    3: (letter1, letter2) => `${letter1}----${letter2}`,
    4: (letter1, letter2) => `*${letter1}--${letter2}*`,
}

function printDNA(length){
    const sequence = 'ATCGTTAGGG';
    let index = 0; //index for sequence
    let countOfLines = 1; //total printed lines
    let count = 1; //count for structure

    while(countOfLines <= length){
        const letter1 = sequence[index++];
        const letter2 = sequence[index++];

        console.log(structure[count](letter1, letter2));

        count++;
        if(count === 5){
            count = 1;
        }

        if(index === sequence.length){
            index = 0;
        }

        countOfLines++;
    }
}
printDNA(10);