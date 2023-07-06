let cutCount = 0;
let lapCount = 0;
let grindCount = 0;
let etchCount = 0;
let xRayCount = 0;
function findDesiredOperations(currChunk, finalThickness){

    while(currChunk / 4 >= finalThickness){
        currChunk /= 4;
        cutCount++;
    }
    printCounts('Cut', cutCount);

    while(currChunk * 0.80 >= finalThickness){
        currChunk *= 0.80;
        lapCount++;
    }
    printCounts('Lap', lapCount);

    while(currChunk - 20 >= finalThickness){
        currChunk -= 20;
        grindCount++;
    }
    printCounts('Grind', grindCount);

    while(currChunk - 2 >= finalThickness - 1){
        currChunk -= 2;
        etchCount++;
    }
    printCounts('Etch', etchCount);

    while(currChunk + 1 <= finalThickness){
        currChunk++;
        xRayCount++;
    }
    if(xRayCount > 0)
    {
        console.log(`X-ray x${xRayCount}`);
    }
    console.log(`Finished crystal ${finalThickness} microns`);
}

function processChunks(input){
    const finalThickness = Number(input[0]);

    for(let i = 1; i < input.length; i++){
        let currChunk = Number(input[i]);
        console.log(`Processing chunk ${currChunk} microns`);
        findDesiredOperations(currChunk, finalThickness);
    }
}

function printCounts(opperation, count) {
    if(count > 0)
    {
        console.log(`${opperation} x${count}`);
        console.log('Transporting and washing');
    }
}
processChunks([1375, 50000]);
processChunks([1000, 4000, 8100]);