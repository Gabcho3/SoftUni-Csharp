function createListOfSongs(input){
    const numberOfSongs = input.shift();
    const neededTypeList = input.pop();

    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
        printName(){
            console.log(this.name);
        }
    }

    const songsToPrint = input.reduce((acc, curr) => {
        const [typeList, name, time] = curr.split('_');
        if(typeList === neededTypeList || neededTypeList === 'all'){
            const song = new Song(typeList, name, time);
            acc.push(song);
        }
        return acc;
    }, []);

    for(const song of songsToPrint){
        song.printName();
    }
}
createListOfSongs([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
    );

createListOfSongs([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
    );