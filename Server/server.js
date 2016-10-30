var io = require('socket.io')(process.env.PORT || 3000);

console.log('server started');

var playerCount = 0;

io.on('connection', function(socket){
    console.log('client connected');
    
    socket.broadcast.emit('spawn');
    
    playerCount++;
    
    for(i = 0; i < playerCount; i++)
        {
            socket.emit('spawn');
            console.log('Sending spawn to new player');
        }
    
    socket.emit('move', {
        slurp: [
            {id: 7},
            {id: 4},
            {id: 6}
        ]
    });
    
    socket.on('move', function(data){
        console.log('client moved');
    })
    //socket.boardcast.emit('move');
})