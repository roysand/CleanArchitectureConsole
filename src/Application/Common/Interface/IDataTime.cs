﻿namespace Application.Common.Interface;

public interface IDateTime
{
    DateTime NowUtc { get; }
    DateTime NowLocalTime { get; }
}