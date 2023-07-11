function registerCarOnParkingLot(input){
    let carsOnParking = new Set();
    input.forEach(entry => {
        const [direction, carNumber] = entry.split(', ');
        switch(direction){
            case 'IN': carsOnParking.add(carNumber); break;
            case 'OUT': 
                carsOnParking.delete(carNumber);
                break;
        }
    });
    carsOnParking = Array.from(carsOnParking).sort();
    console.log(carsOnParking.length > 0 ? carsOnParking.join('\n') : 'Parking Lot is Empty');
}
registerCarOnParkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']);

registerCarOnParkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
);