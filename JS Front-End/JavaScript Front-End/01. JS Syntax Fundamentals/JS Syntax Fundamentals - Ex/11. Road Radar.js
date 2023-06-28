function roadRadar(currSpeed, area){
    let status = '';
    let difference = 0;
    let speedLimit = area === 'motorway' ? 130 : area === 'interstate' ? 90 : area === 'city' ? 50 : 20;
    switch(area){
        case 'motorway': if(currSpeed > speedLimit){ difference = currSpeed - speedLimit; } break;
        case 'interstate': if(currSpeed > speedLimit){ difference = currSpeed - speedLimit; } break;
        case 'city': if(currSpeed > speedLimit){ difference = currSpeed - speedLimit; } break;
        case 'residential': if(currSpeed > speedLimit){ difference = currSpeed - speedLimit; } break;
    }
    if(difference > 0){
        status = difference <= 20 ? 'speeding' : difference <= 40 ? 'excessive speeding' : 'reckless driving';
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
    else{
        console.log(`Driving ${currSpeed} km/h in a ${speedLimit} zone`);
    }
}
roadRadar(40, 'city'); //Driving 40 km/h in a 50 zone
roadRadar(21, 'residential'); //The speed is 1 km/h faster than the allowed speed of 20 - speeding
roadRadar(120, 'interstate'); //The speed is 30 km/h faster than the allowed speed of 90 - excessive speeding
roadRadar(200, 'motorway'); //The speed is 70 km/h faster than the allowed speed of 130 - reckless driving