﻿using System;

namespace SuccincT.Options
{
    public struct Success<T>
    {
        private readonly bool _hasError;
        private readonly T _error;

        internal Success(T error)
        {
            _hasError = true;
            _error = error;
        }

        public bool IsFailure => _hasError;

        public T Failure => _hasError
            ? _error
            : throw new InvalidOperationException("Cannot fetch a Failure for an error-free Success<T> value.");

        public override bool Equals(object obj) => 
            obj is Success<T> other && 
            other._hasError == _hasError &&
            (_hasError && other.Failure.Equals(_error) || !_hasError);

        public override int GetHashCode() => _hasError ? _error.GetHashCode() : 1;

        public static bool operator ==(Success<T> a, object b) => a.Equals(b);

        public static bool operator !=(Success<T> a, object b) => !a.Equals(b);

        public static implicit operator bool(Success<T> success) => !success._hasError;
        public static implicit operator Success<T>(T value) => Success.CreateFailure(value);
    }
}
