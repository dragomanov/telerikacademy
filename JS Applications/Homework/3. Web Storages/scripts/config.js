require.config({
    baseUrl: 'scripts',
    paths: {
        BullsAndCows: 'bulls-and-cows',
        BullsAndCowsUI: 'bulls-and-cows-ui',
        RNG: 'rng',
        jquery: 'bower_components/jquery/dist/jquery',
        Storage: 'storage'
    }
});

require(['app']);