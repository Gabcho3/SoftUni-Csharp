function scheduleMeetings(input){
    const meetings = input.reduce((acc, curr) => {
        const [dayOfWeek, name] = curr.split(' ');

        if(acc.hasOwnProperty(dayOfWeek)){
            console.log(`Conflict on ${dayOfWeek}!`);
        } else{
            acc[dayOfWeek] = name;
            console.log(`Scheduled for ${dayOfWeek}`);
        }

        return acc;
    }, {});

    for(const [dayOfWeek, name] of Object.entries(meetings)){
        console.log(`${dayOfWeek} -> ${name}`);
    }
}
scheduleMeetings(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);