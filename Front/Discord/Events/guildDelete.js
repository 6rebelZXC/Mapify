import client from '../index.js';
import { Events, EmbedBuilder } from 'discord.js';

client.on(Events.GuildDelete, async (guild) => {
    const joinEmbed = new EmbedBuilder()
        .setColor('#df0922')
        .setTitle('🔴 | Left a server')
        .setThumbnail(`${guild.iconURL()}`)
        .setDescription(`:eye: -> ${guild.name}`)
        .addFields(
            { name: 'ID', value: guild.id },
            { name: 'Members', value: String(guild.memberCount) }, // fixed
            { name: 'Owner ID', value: guild.ownerId },
        )
        .setTimestamp()

    const channelId = '1484107483818492055';

    try {
        const channel = await client.channels.fetch(channelId);

        if (!channel?.isTextBased()) {
            console.log('Not a text channel');
            return;
        }
        await channel.send('<@594130786672836611>')
        await channel.send({ embeds: [joinEmbed] });

    } catch (err) {
        console.error('Error sending message:', err);
    }
});