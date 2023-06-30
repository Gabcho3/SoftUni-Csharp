function workProcces(startingYield){
    const crewConsumption = 26;
    let days = 0;
    let extracted = 0;

    while(startingYield >= 100){
        days++;
        extracted += startingYield - crewConsumption;
        startingYield -= 10;
    }
    extracted -= crewConsumption;
    if(extracted < 0){
        extracted -= extracted;
    }

    console.log(days);
    console.log(extracted);
}

workProcces(10);
workProcces(450);