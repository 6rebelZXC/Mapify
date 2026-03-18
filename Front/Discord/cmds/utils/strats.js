import { SlashCommandBuilder, EmbedBuilder } from 'discord.js';
const strats = await fetch('http://localhost:5000/api/strats/');
const data = await strats.json();

const strat = data.find(item => item.id === 1);

const map = await fetch(`http://localhost:5000/api/strats/map/${strat.mapId}`);


export default {
    data: new SlashCommandBuilder().setName('strats').setDescription('Test'),
    async execute(interaction) {

    console.log(map);
// 
    let dickins = strat.description;
    if(dickins == ''){
        dickins = 'No descrtion set.'
    } else {
        dickins = strat.description
    }
// 

// embed

// 
    const exampleEmbed = new EmbedBuilder()
	.setColor(0x0099ff)
	.setTitle(strat.name)
	.setURL('https://'+strat.videoUrl)
	.setDescription(dickins)
	.addFields(
		{ name: 'Strategy ID', value: String(strat.id) },
		{ name: 'Map', value: 'Some value here', inline: true },
		{ name: 'Inline field title', value: 'Some value here', inline: true },
	)
	.setTimestamp()
	.setFooter({ text: 'made with rainbow sex api'});
        interaction.reply({ embeds: [exampleEmbed] });

    },
// 
};