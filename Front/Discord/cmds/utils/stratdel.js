import { SlashCommandBuilder } from 'discord.js';

export default {
    data: new SlashCommandBuilder()
        .setName('strat-delete')
        .setDescription('Delete strategy')
        .addIntegerOption(option =>
            option.setName('id')
                .setDescription('Strategy ID')
                .setRequired(true)
        ),

    async execute(interaction) {

        const id = interaction.options.getInteger('id');

        const res = await fetch(`http://localhost:5000/api/strats/${id}`, {
            method: 'DELETE'
        });

        const data = await res.json();

        await interaction.reply(data.message || 'Done');
    }
};