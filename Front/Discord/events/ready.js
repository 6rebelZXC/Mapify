import Discord, {ActivityType} from 'discord.js'
import { PresenceUpdateStatus } from 'discord.js';
import client from '../index.js'
import chalk from 'chalk'
client.on("ready", async () => {
    console.log('{Event:start} Ready');
    client.user.setActivity('You have been exposed', { type: ActivityType.Watching });
    client.user.setStatus(PresenceUpdateStatus.DoNotDisturb);

});

