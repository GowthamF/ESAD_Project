<template>
    <div>
        <v-list-item>
            <v-list-item-content>
                <v-list-item-title class="text-h6">
                    Pulse
                </v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        
        <v-list
        dense
        nav
        >
        <v-list-item
          v-for="item in getNavigationItems"
          :key="item.title"
          link
          @click="navigate(item.routeName)"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </div>
</template>

<script>
import { useNavigationStore } from '@/stores/navigation'

export default {
    setup() {
        const navigationStore = useNavigationStore();
        return { navigationStore }
    },
    data () {
      return {
        right: null,
      }
    },
    methods:{
        navigate : function(routeName){
            this.navigationStore.navigateToRoute(routeName);
        }
    },
    computed:{
        getNavigationItems(){
            return this.navigationStore.getNavigationMenu();
        }
    },
    props: {
        // items: {
        //     type: Array,
        //     required: true
        // }
    }

  }
</script>

<style>

</style>