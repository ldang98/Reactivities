import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import UserStore from "./userStore";

interface Store {
  activityStore: ActivityStore;
  commonStore: CommonStore;
  userStore: UserStore;
  modalStore: ModalStore;
}

//add instances of stores in here
export const store: Store = {
  activityStore: new ActivityStore(),
  commonStore: new CommonStore(),
  userStore: new UserStore(),
  modalStore: new ModalStore(),
};

//pass the store to context
export const StoreContext = createContext(store);

//hook for components to use context
export function useStore() {
  return useContext(StoreContext);
}
