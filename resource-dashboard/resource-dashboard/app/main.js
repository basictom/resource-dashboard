Vue.config.productionTip = false;

const baseUrl = 'http://localhost:52185/api/resources';

Vue.component('resources', {
    template: '#resource-list',
    data: {
        response : []
    },
    mounted() {
        this.getRes();
    },
    methods: {
        getRes() {
            this.$http.get(baseUrl).then(res => {
                this.response = res.data;
                console.log(this.response);
            }).catch(error => {
                console.log(error);
            })
        }
    },
    computed: {
        //This will contain the tags searching logic
        filterResources() {
            return console.log("inside computed", response);
        }
    }
});


var vm = new Vue({
    el: '#app',
    data: "Hello world"
});