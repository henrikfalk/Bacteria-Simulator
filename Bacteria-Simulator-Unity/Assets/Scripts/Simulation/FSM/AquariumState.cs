using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AquariumState
{

    public enum STATE {
        EMPTY,
        INITIALIZING,
        RUNNING,
        PAUSED
    };

    public enum EVENT {
        ENTER,
        UPDATE,
        EXIT
    };

    public enum SIGNAL {
        NONE,
        NEW_SIMULATION,
        QUIT_SIMULATION,
        PAUSE_SIMULATION,
        ADD_DETOX,
        ADD_FOOD,
        EXIT_SIMULATION
    };

    public STATE stateName;

    protected EVENT stage;

    protected SIGNAL signal;

    protected AquariumState nextState;

    protected SimulationController simulationController;

    public AquariumState(SimulationController _simulationController) {

        simulationController = _simulationController;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public AquariumState Process() {

        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT) {

            Exit();
            return nextState;
        }

        return this;
    }

    // Send signal to FSM (to simulate keystrokes)
    public void Signal(SIGNAL _signal) {
        signal = _signal;
    }

}
