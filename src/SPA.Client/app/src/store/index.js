import { createStore } from 'vuex'

export const store = createStore({
    state () {
        return {
            user: null
        }
    }
})

/*
createApp.use(Vuex)

const state = {
    user: null
}

export default new Vuex.Store({
    state
})*/