import Discord, {ActivityType} from 'discord.js'
import pkg from 'discord.js';
const { PresenceUpdateStatus, readyClient, Events} = pkg;
import client from '../index.js'
import chalk from 'chalk'
client.on(Events.ClientReady, readyClient => {
    
    console.log('{Event:start} Ready');
    console.log(`Logged in as ${readyClient.user.tag}!`);
    client.user.setActivity('Strats — /help', { type: ActivityType.Watching });
    client.user.setStatus(PresenceUpdateStatus.DoNotDisturb);

});

