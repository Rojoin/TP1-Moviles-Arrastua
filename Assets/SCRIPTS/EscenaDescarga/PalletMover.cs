﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletMover : ManejoPallets
{
    public MoveType miInput;
    private string horizontalInputPlayer1;
    private string verticalInputPlayer1;
    private string horizontalInputPlayer2;
    private string verticalInputPlayer2;

    public enum MoveType
    {
        WASD,
        Arrows
    }

    public ManejoPallets Desde, Hasta;
    bool segundoCompleto = false;

    private void Start()
    {
        horizontalInputPlayer1 = $"Horizontal{0}";
        verticalInputPlayer1 = $"Vertical{0}";
        horizontalInputPlayer2 = $"Horizontal{1}";
        verticalInputPlayer2 = $"Vertical{1}";
    }

    private void Update()
    {
        float controlValue = 0.5f;
        switch (miInput)
        {
            case MoveType.WASD:
                if (!Tenencia() && Desde.Tenencia() &&
                    InputManager.Instance.GetAxis(horizontalInputPlayer1) < -controlValue)
                {
                    PrimerPaso();
                }


                if (Tenencia() && InputManager.Instance.GetAxis(verticalInputPlayer1) < -controlValue)
                {
                    SegundoPaso();
                }

                if (segundoCompleto && Tenencia() &&
                    InputManager.Instance.GetAxis(horizontalInputPlayer1) > controlValue)
                {
                    TercerPaso();
                }


                break;
            case MoveType.Arrows:
                if (!Tenencia() && Desde.Tenencia() &&
                    InputManager.Instance.GetAxis(horizontalInputPlayer2) < -controlValue)
                {
                    PrimerPaso();
                }

                if (Tenencia() && InputManager.Instance.GetAxis(verticalInputPlayer2) < -controlValue)
                {
                    SegundoPaso();
                }

                if (segundoCompleto && Tenencia() &&
                    InputManager.Instance.GetAxis(horizontalInputPlayer2) > controlValue)
                {
                    TercerPaso();
                }

                break;
            default:
                break;
        }
    }

    void PrimerPaso()
    {
        Desde.Dar(this);
        segundoCompleto = false;
    }

    void SegundoPaso()
    {
        base.Pallets[0].transform.position = transform.position;
        segundoCompleto = true;
    }

    void TercerPaso()
    {
        Dar(Hasta);
        SoundManager.Instance.PlayMoneySound();
        segundoCompleto = false;
    }

    public override void Dar(ManejoPallets receptor)
    {
        if (Tenencia())
        {
            if (receptor.Recibir(Pallets[0]))
            {
                Pallets.RemoveAt(0);
            }
        }
    }

    public override bool Recibir(Pallet pallet)
    {
        if (!Tenencia())
        {
            pallet.Portador = this.gameObject;
            base.Recibir(pallet);
            return true;
        }
        else
            return false;
    }
}